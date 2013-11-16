using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Slicing
{
    public class PreProcessor
    {
        private enum TokenType
        {
            NONE,
            NAME,
            NUMBER,
            END,
            VAR = '$',
            MOD = '%',
            PLUS = '+',
            MINUS = '-',
            MULTIPLY = '*',
            DIVIDE = '/',
            ASSIGN = '=',
            LHPAREN = '(',
            RHPAREN = ')',
            COMMA = ',',
            NOT = '!',

            // comparisons
            LT = '<',
            GT = '>',
            LE,     // <=
            GE,     // >=
            EQ,     // ==
            NE,     // !=
            AND,    // &&
            OR,      // ||
            BITAND, // &
            BITOR,  // |
            SHR,    // >>
            SHL,    // <<

            // special assignments

            ASSIGN_ADD,  //  +=
            ASSIGN_SUB,  //  +-
            ASSIGN_MUL,  //  +*
            ASSIGN_DIV   //  +/
        }
        private string program_; // the entire "program"
        private TokenType type_; // current token type
        private string word_; // current token word
        private double value_; // current value
        private int pWord_; //Index
        private int pWordStart_; //Index
        public delegate void PreProcessorErrorHandler(PreProcessor preproc, string message);
        public event PreProcessorErrorHandler ParseErrorEvent;
        Dictionary<String, double> symbols_;

        public PreProcessor()
        {
            symbols_ = new Dictionary<String, double>();
        }

        public void SetVar(String name, double data)
        {
            symbols_[name] = data;
        }

        public String Process(String code)
        {
            StringBuilder sbcode = new StringBuilder();
            StringBuilder sbexpr = new StringBuilder();
            Boolean in_comment = false;
            Boolean in_expr = false;
            int prcount = 0;

            foreach (char ch in code)
            {
                if (in_expr) 
                {
                    if (prcount > 0) {
                        // extracting expression within parenthesis
                        sbexpr.Append(ch);
                        if (ch == '(')
                            prcount ++;
                        else if (ch == ')')
                        {
                            prcount--;
                            if (prcount == 0)
                            {
                                in_expr = false;
                                sbcode.Append(Evaluate(sbexpr.ToString()).ToString("F4").Replace(',', '.'));
                                sbexpr.Length = 0;
                            }
                        }
                    }
                    else
                    {
                        // extracting a single var
                        if (!isalnum(ch))
                        {
                            in_expr = false;
                            sbcode.Append(Evaluate(sbexpr.ToString()).ToString("F4").Replace(',', '.'));
                            sbexpr.Length = 0;
                            sbcode.Append(ch);
                        } else {
                            sbexpr.Append(ch);
                        }
                    }
                } 
                else 
                {
                    sbcode.Append(ch);
                    if (in_comment)
                    {
                        if (ch == '\n')
                            in_comment = false;
                    }
                    else if (ch == ';')
                    {
                        in_comment = true;
                    }
                    else if ((ch == '(') || (ch == '$'))
                    {
                        sbcode.Length--;
                        sbexpr.Append(ch);
                        in_expr = true;
                        if (ch == '(')
                            prcount++;
                    }
                }
            }
            return sbcode.ToString();
        }

        public double this[string name]
        {
            set
            {
                double val = 0;
                if (symbols_.TryGetValue(name, out val))
                {
                    symbols_[name] = value;
                }
                else
                {
                    symbols_.Add(name, value);
                }
            }
            get
            {
                double val = 0;
                if (symbols_.TryGetValue(name, out val))
                {
                    return symbols_[name];
                }
                return val;
            }
        }

        void CheckToken(TokenType wanted)
        {
            if (type_ != wanted)
            {
                RaiseError("Unexpected token at index " + pWord_.ToString());
            }
        }
        /*
        long DoMin (long arg1, long arg2)
        {
            return (arg1 < arg2 ? arg1 : arg2);
        }

        long DoMax (long arg1, long arg2)
        {
            return (arg1 > arg2 ? arg1 : arg2);
        }
        */
        double DoIf(long arg1, double arg2, double arg3)
        {
            if (arg1 != 0)
                return arg2;
            else
                return arg3;
        }
        bool ishexdigit(char C)
        {
            if ((C >= '0') && (C <= '9')) return true;
            if (((C >= 'A') && (C <= 'F')) || ((C >= 'a') && (C <= 'f'))) return true;
            return false;
        }

        protected double Evaluate()  // get result
        {
            double v = CommaList(true);
            if (type_ != TokenType.END)
            {
                RaiseError("Unexpected text at end of expression: " + pWordStart_.ToString());
            }
            return v;
        }

        // change program and evaluate it
        public double Evaluate(string program)  // get result
        {
            // do same stuff constructor did
            program_ = program;
            pWord_ = 0; // 0 index 
            pWordStart_ = 0;
            type_ = TokenType.NONE;
            return Evaluate();
        }

        double CommaList(bool getit)  // expr1, expr2
        {
            double left = Expression(getit);
            while (true)
            {
                switch (type_)
                {
                    case TokenType.COMMA:
                        left = Expression(true);
                        break; // discard previous value
                    default:
                        return left;
                } // end of switch on type
            }   // end of loop
        } // end of Parser::CommaList

        double Expression(bool getit)  // AND and OR
        {
            double left = Comparison(getit);
            while (true)
            {
                switch (type_)
                {
                    case TokenType.AND:
                        long d = (long)Comparison(true);   // don't want short-circuit evaluation
                        if ((left != 0) && (d != 0))
                        {
                            left = 1;
                        }
                        else { left = 0; }
                        break;
                    case TokenType.OR:
                        long cmp = (long)Comparison(true);   // don't want short-circuit evaluation
                        if ((left != 0) || (cmp != 0))
                        {
                            left = 1;
                        }
                        else { left = 0; }

                        break;
                    default:
                        return left;
                } // end of switch on type
            }   // end of loop
        } // end of Parser::Expression

        double Comparison(bool getit)  // LT, GT, LE, EQ etc.
        {
            double left = AddSubtract(getit);
            while (true)
            {
                switch (type_)
                {
                    case TokenType.LT: left = left < AddSubtract(true) ? 1 : 0; break;
                    case TokenType.GT: left = left > AddSubtract(true) ? 1 : 0; break;
                    case TokenType.LE: left = left <= AddSubtract(true) ? 1 : 0; break;
                    case TokenType.GE: left = left >= AddSubtract(true) ? 1 : 0; break;
                    case TokenType.EQ: left = left == AddSubtract(true) ? 1 : 0; break;
                    case TokenType.NE: left = left != AddSubtract(true) ? 1 : 0; break;
                    default: return left;
                } // end of switch on type
            }   // end of loop
        } // end of Parser::Comparison

        double AddSubtract(bool getit)  // add and subtract
        {
            double left = Term(getit);
            while (true)
            {
                switch (type_)
                {
                    case TokenType.PLUS: left += Term(true); break;
                    case TokenType.MINUS: left -= Term(true); break;
                    default: return left;
                } // end of switch on type
            }   // end of loop
        } // end of Parser::AddSubtract

        double Term(bool getit)    // multiply and divide
        {
            double left = Primary(getit);
            long l = 0;
            while (true)
            {
                switch (type_)
                {
                    case TokenType.BITAND:
                        l = (long)left;
                        l &= (long)Primary(true);
                        left = l;
                        break;
                    case TokenType.BITOR:
                        l = (long)left;
                        l |= (long)Primary(true);
                        left = l;
                        break;
                    case TokenType.SHR:
                        l = (long)left;
                        l >>= (int)Primary(true);
                        left = l;
                        break;
                    case TokenType.SHL:
                        l = (long)left;
                        l <<= (int)Primary(true);
                        left = l;
                        break;
                    case TokenType.MOD:
                        left %= Primary(true); break;
                    case TokenType.MULTIPLY:
                        left *= Primary(true); break;
                    case TokenType.DIVIDE:
                        double d = Primary(true);
                        if (d == 0.0)
                        {
                            RaiseError("Unexpected text at end of expression: " + pWordStart_.ToString());
                        }
                        left /= d;
                        break;

                    default: return left;
                } // end of switch on type
            }   // end of loop
        } // end of Parser::Term

        double Primary(bool getit)   // primary (base) tokens
        {
            if (getit)
                GetToken(false);    // one-token lookahead  

            switch (type_)
            {
                case TokenType.NUMBER:
                    {
                        double v = value_;
                        GetToken(true);  // get next one (one-token lookahead)
                        return v;
                    }

                case TokenType.NAME:
                    {
                        string word = word_;
                        GetToken(true);
                        if (type_ == TokenType.LHPAREN)
                        {
                            if (word == "if" || word == "IF")
                            {
                                long v1 = (long)Expression(true);   // get argument 1 (not commalist)
                                CheckToken(TokenType.COMMA);
                                double v2 = Expression(true);   // get argument 2 (not commalist)
                                CheckToken(TokenType.COMMA);
                                double v3 = Expression(true);   // get argument 3 (not commalist)
                                CheckToken(TokenType.RHPAREN);
                                GetToken(true);  // get next one (one-token lookahead)
                                return DoIf(v1, v2, v3); // evaluate function

                            }
                            RaiseError("Function '" + word + "' not implemented.");
                            return 0;
                        }

                        //not a function? its a local variable
                        //long & v = symbols_ [word];  // get REFERENCE to symbol table entry
                        // change table entry with expression? (eg. a = 22, or a = 22)
                        switch (type_)
                        {
                            // maybe check for NaN or Inf here (see: isinf, isnan functions)
                            case TokenType.ASSIGN: this[word] = Expression(true); break;
                            case TokenType.ASSIGN_ADD: this[word] += Expression(true); break;
                            case TokenType.ASSIGN_SUB: this[word] -= Expression(true); break;
                            case TokenType.ASSIGN_MUL: this[word] *= Expression(true); break;
                            case TokenType.ASSIGN_DIV:
                                {
                                    double d = Expression(true);
                                    if (d == 0)
                                    {
                                        RaiseError("Divide by 0");
                                    }
                                    this[word] /= d;
                                    break;   // change table entry with expression
                                } // end of ASSIGN_DIV
                            default: break;   // do nothing for others
                        } // end of switch on type_              
                        return this[word];               // and return new value
                    }

                case TokenType.VAR:
                    {
                        GetToken(true);
                        if (type_ != TokenType.NAME)
                        {
                            RaiseError("Expected external variable name after '$'");
                            return 0;
                        }
                        string word = "$"+word_;
                        GetToken(true);  // get next one (one-token lookahead)
                        if (symbols_.ContainsKey(word))
                            return symbols_[word];
                        RaiseError("Unknown variable " + word);
                        return 0;
                    }

                case TokenType.MINUS:               // unary minus
                    return -Primary(true);

                case TokenType.NOT:   // unary not
                    return (Primary(true) == 0) ? 1 : 0; ;

                case TokenType.LHPAREN:
                    {
                        double v = CommaList(true);    // inside parens, you could have commas
                        CheckToken(TokenType.RHPAREN);
                        GetToken(true);                // eat the )
                        return v;
                    }

                default:
                    RaiseError("Unexpected Token " + word_);
                    break;
            } // end of switch on type
            return 0;
        } // end of Parser::Primary 

        bool isdigit(char c)
        {
            if (c >= '0' && c <= '9') return true;
            return false;
        }
        bool isalnum(char c)
        {
            if (isalpha(c) || isdigit(c) || (c == '_')) return true;
            return false;
        }
        bool isalpha(char c)
        {
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                return true;
            return false;
        }
        bool isspace(char c) 
        {
            if(c == ' ' || c == '\r' || c == '\n' || c == '\t')
                return true;

            return false;
        }
        private void RaiseError(string error) 
        {
            if (ParseErrorEvent != null) 
            {
                ParseErrorEvent(this, error);
            }
        }

        TokenType GetToken (bool ignoreSign)
        {
            word_ = "";
            
            if (pWord_ >= (program_.Length - 1))    // stop at end of file
            {
                word_ = "<end of expression>";
                return type_ = TokenType.END;
            }
            // skip spaces
            while (isspace(program_[pWord_]))
            {
                pWord_++;
            }
	        
	        pWordStart_ = pWord_;   // remember where word_ starts *now*
            // look out for unterminated statements and things
            if(pWord_ >= program_.Length-1 && type_ == TokenType.END)
            {
                RaiseError("Unexpected end of expression.");
            }
	        
	        char cFirstCharacter = program_[pWord_];        // first character in new word_
          
	        if (pWord_ == (program_.Length-1))    // stop at end of file
	        {
		        word_ = "<end of expression>";
		        return type_ = TokenType.END;
	        }
          
	        char cNextCharacter  = program_[pWord_ + 1];  // 2nd character in new word_

	        //check for hex numbers first
	        if(isdigit (cFirstCharacter)&& (cNextCharacter == 'x' || cNextCharacter == 'X'))
	        {
		        pWord_ +=2; // skip the 0x or 0X portion to the next digit
                while ((pWord_ < program_.Length) && ishexdigit(program_[pWord_]))
                {
			        pWord_ ++;      
                }
        	    word_ = program_.Substring(pWordStart_, pWord_ - pWordStart_);
                try
                {
        	        value_ = Convert.ToInt64(word_,16);
                }catch(Exception )
                {
                    RaiseError("Error converting Hex at " + pWordStart_.ToString());
                }

		        return type_ =  TokenType.NUMBER;
	        }

	        // look for number
	        // can be: + or - followed by a decimal point
	        // or: + or - followed by a digit
	        // or: starting with a digit
	        // or: decimal point followed by a digit
	        if ((!ignoreSign &&
	        (cFirstCharacter == '+' || cFirstCharacter == '-') &&
	        (isdigit (cNextCharacter) || cNextCharacter == '.')
	        )|| isdigit (cFirstCharacter)	  
	        || (cFirstCharacter == '.' && isdigit (cNextCharacter)) )// allow decimal numbers without a leading 0. e.g. ".5", Dennis Jones 01-30-2009
	        {
		        // skip sign for now
		        if ((cFirstCharacter == '+' || cFirstCharacter == '-'))
		          pWord_++;

		        while (isdigit (program_[pWord_]))
		          pWord_++;
        	           	    
		        word_ = program_.Substring(pWordStart_, pWord_ - pWordStart_);
        	    try
                {
                    value_ = Double.Parse(word_);
                }
                catch(Exception)
                {
                    RaiseError("Bad numeric literal: " + word_);
                }
                return type_ = TokenType.NUMBER;
            }   // end of number found

	          // special test for 2-character sequences: <= >= == !=
	          // also +=, -=, /=, *=
	        if (cNextCharacter == '=')
	        {
		        switch (cFirstCharacter)
		        {
			        // comparisons
			        case '=': type_ = TokenType.EQ;   break;
			        case '<': type_ = TokenType.LE;   break;
			        case '>': type_ = TokenType.GE;   break;
			        case '!': type_ = TokenType.NE;   break;
			        // assignments
			        case '+': type_ = TokenType.ASSIGN_ADD;   break;
			        case '-': type_ = TokenType.ASSIGN_SUB;   break;
			        case '*': type_ = TokenType.ASSIGN_MUL;   break;
			        case '/': type_ = TokenType.ASSIGN_DIV;   break;
        			
			        // none of the above
			        default:  type_ = TokenType.NONE; break;
		        } // end of switch on cFirstCharacter

		        if (type_ != TokenType.NONE)
		        {
			        word_ = program_.Substring(pWordStart_, 2);
			        pWord_ += 2;   // skip both characters
			        return type_;
		        } // end of found one    
	        } // end of *=
          
          switch (cFirstCharacter)
            {
		        case '&': 
			        if (cNextCharacter == '&')    // &&
			        {
				        word_ = program_.Substring(pWordStart_, 2);
				        pWord_ += 2;   // skip both characters
				        return type_ = TokenType.AND;
			        }
			        else
			        {
				        word_ = program_.Substring(pWordStart_, 1);
				        pWord_ += 1;
				        return type_ = TokenType.BITAND;				
			        }
		        case '|': 
			        if (cNextCharacter == '|')   // ||
			        {
				        word_ = program_.Substring(pWordStart_, 2);
				        pWord_ += 2;   // skip both characters
				        return type_ = TokenType.OR;
			        }
			        else
			        {
				        word_ = program_.Substring(pWordStart_, 1);
				        pWord_ += 1;   // skip both characters
				        return type_ = TokenType.BITOR;			
			        }
		        case '<':
			        if (cNextCharacter == '<')   // <<
			        {
				        word_ = program_.Substring(pWordStart_, 2);
				        pWord_ += 2;   // skip both characters
				        return type_ = TokenType.SHL;
			        }
			        else
			        {
			          word_ = program_.Substring(pWordStart_, 1);
			          ++pWord_;   // skip it
			          return type_ = TokenType.LT;
			        }
		        case '>':
			        if (cNextCharacter == '>')   // >>
			        {
				        word_ = program_.Substring(pWordStart_, 2);
				        pWord_ += 2;   // skip both characters
				        return type_ = TokenType.SHR;
			        }
			        else
			        {
			          word_ = program_.Substring(pWordStart_, 1);
			          ++pWord_;   // skip it
			          return type_ = TokenType.GT;
			        }
            // single-character symboles
            case '=':
            case '+':
            case '-':
            case '/':
            case '*':
            case '%':
            case '$':
            case '(':
            case ')':
            case ',':
            case '!':
              word_ = program_.Substring(pWordStart_, 1);
              ++pWord_;   // skip it
              type_ = (TokenType)cFirstCharacter;
              return type_;
            } // end of switch on cFirstCharacter
          
          if (!isalpha (cFirstCharacter))
            {
            if (cFirstCharacter < ' ')
              {
                RaiseError("Unexpected character at " + pWordStart_.ToString() );
              }
            else
                RaiseError("Unexpected character at " + pWordStart_.ToString() );
            }
          
          // we have a word (starting with A-Z) - pull it out
          while ((isalnum(program_[pWord_]) || program_[pWord_] == '_'))
          {
              ++pWord_;
              if (pWord_ == program_.Length)
                  break;
          }
          
          word_ = program_.Substring(pWordStart_, pWord_ - pWordStart_);

          return type_ = TokenType.NAME;
          }   // end of Parser::GetToken

    }
}
